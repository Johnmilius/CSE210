import re
import json

def clean_description(desc):
    if not desc:
        return None
    # Remove HTML tags
    desc = re.sub(r'<[^>]+>', '', desc)
    # Remove extra whitespace
    desc = desc.strip()
    # Remove non-meaningful or placeholder descriptions
    if desc.lower() in ["n/a", "none", "", "-", "description", "no description"]:
        return None
    return desc

def clean_card_descriptions(json_path):
    with open(json_path, encoding="utf-8") as f:
        cards = json.load(f)
    for card in cards:
        if "description" in card:
            card["description"] = clean_description(card["description"])
    with open(json_path, "w", encoding="utf-8") as f:
        json.dump(cards, f, indent=2, ensure_ascii=False)
    print(f"Cleaned descriptions in {json_path}")

if __name__ == "__main__":
    clean_card_descriptions(r"final/finalProject/card_Data/special_power_cards.json")
