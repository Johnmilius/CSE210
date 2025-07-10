import json

def extract_unique_power_effects(json_path):
    with open(json_path, encoding="utf-8") as f:
        cards = json.load(f)
    effects = set()
    for card in cards:
        effect = card.get("PowerCardEffectType")
        if effect:
            effects.add(effect.strip())
    print("Unique PowerCardEffectType values:")
    for effect in sorted(effects):
        print(effect)
    print(f"\nTotal unique effects: {len(effects)}")

if __name__ == "__main__":
    extract_unique_power_effects(r"final\FinalProject\card_Data\special_power_cards.json")
