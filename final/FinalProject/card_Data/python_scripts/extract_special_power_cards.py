import re
import json

def extract_power_cards(filename, output_json):
    with open(filename, encoding="utf-8") as f:
        text = f.read()

    # Find all card rows (limit to first 100 lines for pattern analysis)
    rows = re.findall(r'<tr id="card_\d+">(.+?)</tr>', text, re.DOTALL)
    cards = []
    for row in rows:
        # Card ID
        card_id = re.search(r'<a [^>]*>(\d+)</a>', row)
        card_id = int(card_id.group(1)) if card_id else None

        # Name
        name = re.search(r'title="[^"]*">([^<]+)</a>', row)
        if not name:
            name = re.search(r'<td>([A-Z0-9\s]+)</td>', row)
        name = name.group(1).strip() if name else None

        # Image URL
        image_url = re.search(r'<img src="([^"]+Card-Jitsu_Cards_full_\d+\.png)', row)
        image_url = image_url.group(1) if image_url else None

        # Element
        element = re.search(r'<figcaption>(Fire|Water|Snow)</figcaption>', row)
        element = element.group(1) if element else None

        # Value: look for Burbank_# pattern and use that number as the value
        value_match = re.search(r'Burbank_(\d+)', row)
        value = int(value_match.group(1)) if value_match else None

        # Color
        color = re.search(r'<figcaption>(Red|Blue|Green|Yellow|Orange|Purple)</figcaption>', row)
        color = color.group(1) if color else None

        # Description (last <td> in the row)
        desc_match = re.findall(r'<td[^>]*>(.*?)</td>', row, re.DOTALL)
        description = desc_match[-1].strip() if desc_match else None
        description = re.sub(r'<[^>]+>', '', description) if description else None

        # Power card effect type: grab the line with 'style="text-align: center;"><figure class="mw-halign-center"'
        effect_type_line = None
        for line in row.split('\n'):
            if 'style="text-align: center;"><figure class="mw-halign-center"' in line:
                effect_type_line = line.strip()
                break

        card = {
            "cardId": card_id,
            "name": name,
            "ElementType": element,
            "CardColor": color,
            "value": value,
            "imageUrl": image_url,
            "description": description,
            "PowerCardEffectType": effect_type_line
        }
        cards.append(card)

    # Write to JSON
    with open(output_json, "w", encoding="utf-8") as out:
        json.dump(cards, out, indent=2, ensure_ascii=False)
    print(f"Extracted {len(cards)} power cards to {output_json}")

if __name__ == "__main__":
    extract_power_cards(r"final/finalProject/card_Data/cj_cardInfo_SpecialCards.txt", "special_power_cards.json")


print('done')