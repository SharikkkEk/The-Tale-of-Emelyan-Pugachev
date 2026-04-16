import re

# Read the original meta file
with open(r"C:\Users\ILYA\Documents\Projects\Project history\SkyBound-Quest-main\SkyBoundQuest\Assets\LawlessGames\Tactics Toolkit\Images\forTown\MCBlocksBlackOutline.png.meta", "r") as f:
    meta_content = f.read()

# Read the generated sprites section
with open(r"C:\Users\ILYA\Documents\Projects\Project history\SkyBound-Quest-main\SkyBoundQuest\output.txt", "r") as f:
    generated_content = f.read()

# Split the generated content into sprites and name table
parts = generated_content.split("\n\nnameFileIdTable:")
sprites_text = parts[0]
name_table_text = parts[1] if len(parts) > 1 else ""

# Find and replace the sprites section
pattern = r'(  spriteSheet:\n    serializedVersion: 2\n    sprites:)[\s\S]*?(\n    outline: \[\])'
replacement = r'\1' + sprites_text.replace("sprites:", "") + r'\2'
meta_content = re.sub(pattern, replacement, meta_content)

# Find and replace the name table section
pattern2 = r'(    nameFileIdTable:) \{\}'
replacement2 = r'\1' + name_table_text
meta_content = re.sub(pattern2, replacement2, meta_content)

# Write the updated meta file
with open(r"C:\Users\ILYA\Documents\Projects\Project history\SkyBound-Quest-main\SkyBoundQuest\Assets\LawlessGames\Tactics Toolkit\Images\forTown\MCBlocksBlackOutline.png.meta", "w") as f:
    f.write(meta_content)

print("Done!")
