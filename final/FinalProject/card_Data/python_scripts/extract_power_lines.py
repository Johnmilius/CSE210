import re

# This script extracts the last line containing 'data-sort-value' for each <tr id="card_..."> section in the input file.
def extract_last_power_line(input_path, output_path):
    with open(input_path, encoding="utf-8") as f:
        text = f.read()

    # Find all card rows
    rows = re.findall(r'<tr id="card_\d+">(.+?)</tr>', text, re.DOTALL)
    power_lines = []
    for row in rows:
        # Find all lines with data-sort-value
        lines = re.findall(r'(.*data-sort-value="\d+".*)', row)
        if lines:
            # Get the last such line
            last_line = lines[-1].strip()
            power_lines.append(last_line)

    # Write all last power lines to output file (one per line)
    with open(output_path, "w", encoding="utf-8") as out:
        for line in power_lines:
            out.write(line + "\n")
    print(f"Extracted {len(power_lines)} power lines to {output_path}")

if __name__ == "__main__":
    extract_last_power_line("cj_cardInfo_SpecialCards.txt", "special_power_lines.txt")
