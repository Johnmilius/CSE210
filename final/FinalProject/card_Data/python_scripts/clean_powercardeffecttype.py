import json
import re

def clean_powercardeffecttype(json_path, output_path):
    with open(json_path, encoding="utf-8") as f:
        cards = json.load(f)
    for card in cards:
        effect_html = card.get("PowerCardEffectType", "")
        # Extract value inside data-image-name="..."
        match = re.search(r'data-image-name="([^"]+)"', effect_html)
        if match:
            card["PowerCardEffectType"] = match.group(1)
        else:
            card["PowerCardEffectType"] = None
    with open(output_path, "w", encoding="utf-8") as f:
        json.dump(cards, f, indent=2, ensure_ascii=False)
    print(f"Cleaned PowerCardEffectType values written to {output_path}")

if __name__ == "__main__":
    clean_powercardeffecttype(r"final\FinalProject\card_Data\special_power_cards.json", "special_power_cards_cleaned.json")

print("done")