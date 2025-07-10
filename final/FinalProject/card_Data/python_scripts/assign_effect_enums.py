import json
from difflib import get_close_matches

# List of enums as provided
EFFECT_ENUMS = [
    "None",
    "PowerReverse",
    "NextCardValueUp2User",
    "NextCardValueDown2Opponent",
    "LowerValueCardWins",
    "DiscardRandomFireCardOppenent",
    "DiscardRandomWaterCardOppenent",
    "DiscardRandomSnowCardOppenent",
    "DiscardRandomRedCardOppenent",
    "DiscardAllRedOpponentCards",
    "DiscardRandomBlueCardOppenent",
    "DiscardAllBlueOpponentCards",
    "DiscardRandomYellowCardOppenent",
    "DiscardAllYellowOpponentCards",
    "DiscardRandomGreenCardOppenent",
    "DiscardAllGreenOpponentCards",
    "DiscardRandomOrangeCardOppenent",
    "DiscardAllOrangeOpponentCards",
    "DiscardRandomPurpleCardOppenent",
    "DiscardAllPurpleOpponentCards",
    "ChangeFireToSnowThisTurnOppenent",
    "ChangeSnowToWaterThisTurnOppenent",
    "ChangeWaterToFireThisTurnOppenent",
    "BlockFireNextTurnOppenent",
    "BlockWaterNextTurnOppenent",
    "BlockSnowNextTurnOppenent"
]

def load_cards(json_path):
    with open(json_path, 'r', encoding='utf-8') as f:
        return json.load(f)

def get_unique_effects(cards):
    effects = set()
    for card in cards:
        effect = card.get('PowerCardEffectType', '').strip()
        if effect:
            effects.add(effect)
    return list(effects)

def match_enum(effect, enums):
    # Try to find the closest enum using fuzzy matching
    matches = get_close_matches(effect.replace(' ', ''), enums, n=1, cutoff=0.4)
    if matches:
        return matches[0]
    return "None"

def assign_enums_to_cards(cards, enums):
    for card in cards:
        effect = card.get('PowerCardEffectType', '').strip()
        name = (card.get('name') or '').strip().lower()
        print(f"Original effect: {effect}")
        # Special handling for +2 and -2 Power
        if '+2 power' in effect.lower() or '+2 power' in name:
            matched_enum = 'NextCardValueUp2User'
            print(f"Special case: +2 Power detected, setting to {matched_enum}")
        elif '-2 power' in effect.lower() or '-2 power' in name:
            matched_enum = 'NextCardValueDown2Opponent'
            print(f"Special case: -2 Power detected, setting to {matched_enum}")
        elif effect:
            matched_enum = match_enum(effect, enums)
            print(f"Matched enum: {matched_enum}")
        else:
            print("No effect found, setting to None")
            matched_enum = "None"
        card['PowerCardEffectType'] = matched_enum
        print(f"Updated card: {card}\n")
    return cards

def main():
    json_path = r"final\FinalProject\card_Data\special_power_cards_cleaned.json" # Update if needed
    output_path = 'specialpower_cards_with_enums.json'
    cards = load_cards(json_path)
    unique_effects = get_unique_effects(cards)
    print("Unique effects:")
    for eff in unique_effects:
        print(eff)
    print("\n--- Assigning enums to cards ---\n")
    cards_with_enums = assign_enums_to_cards(cards, EFFECT_ENUMS)
    with open(output_path, 'w', encoding='utf-8') as f:
        json.dump(cards_with_enums, f, indent=2)
    print(f"Output written to {output_path}")

if __name__ == "__main__":
    main()
