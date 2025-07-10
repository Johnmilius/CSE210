import re
import json

def extract_cards(filename):
    with open(filename, encoding="utf-8") as f:
        text = f.read()

    # Split by each card row
    rows = re.findall(r'<tr id="card_\d+">(.+?)</tr>', text, re.DOTALL)
    cards = []
    for row in rows:
        # Card ID
        card_id = re.search(r'<a [^>]*>(\d+)</a>', row)
        card_id = int(card_id.group(1)) if card_id else None

        # Name
        name = re.search(r'title="[^"]*">([^<]+)</a>', row)
        name = name.group(1).strip() if name else None

        # Image URL
        image_url = re.search(r'<img src="([^"]+Card-Jitsu_Cards_full_\d+\.png)', row)
        image_url = image_url.group(1) if image_url else None

        # Element
        element = re.search(r'<figcaption>(Fire|Water|Snow)</figcaption>', row)
        element = element.group(1) if element else None

        # Value (first data-sort-value after element)
        value = re.findall(r'data-sort-value="(\d+)"', row)
        value = int(value[1]) if len(value) > 1 else (int(value[0]) if value else None)

        # Color
        color = re.search(r'<figcaption>(Red|Blue|Green|Yellow|Orange|Purple)</figcaption>', row)
        color = color.group(1) if color else None

        # Description (last <td> in the row)
        desc_match = re.findall(r'<td[^>]*>([^<]+(?:<a [^>]+>[^<]+</a>)*[^<]*)</td>', row)
        description = desc_match[-1].strip() if desc_match else None

        # Power card effect type (guess from description or name)
        effect_type = None


        card = {
            "cardId": card_id,
            "name": name,
            "ElementType": element,
            "value": value,
            "CardColor": color,
            "imageUrl": image_url,
            "description": description,
            "PowerCardEffectType": effect_type
        }
        cards.append(card)
    return cards

cards = extract_cards(r"final/finalProject/card_Data/cj_cardInfo_5-8.txt")

# Write to a new JSON file
with open("cards_5-8.json", "w", encoding="utf-8") as out:
    json.dump(cards, out, indent=2)

print("done")