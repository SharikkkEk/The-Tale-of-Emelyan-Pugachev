rows = 54
cols = 18
internal_id = 21300000

sprites_section = "sprites:"
name_table_section = "nameFileIdTable:"

for row in range(rows):
    for col in range(cols):
        x = col * 32
        y = (rows - 1 - row) * 32
        idx = row * cols + col
        name = f"Block_{idx}"
        
        sprites_section += f"""
    - serializedVersion: 2
      name: {name}
      rect:
        serializedVersion: 2
        x: {x}
        y: {y}
        width: 32
        height: 32
      alignment: 0
      pivot: {{x: 0, y: 0}}
      border: {{x: 0, y: 0, z: 0, w: 0}}
      outline: []
      physicsShape: []
      tessellationDetail: 0
      bones: []
      spriteID: 
      internalID: {internal_id}
      vertices: []
      indices: 
      edges: []
      weights: []"""
        
        name_table_section = name_table_section + f"""
      {name}: {internal_id}"""
        internal_id += 2

with open(r"C:\Users\ILYA\Documents\Projects\Project history\SkyBound-Quest-main\SkyBoundQuest\output.txt", "w") as f:
    f.write(sprites_section + "\n\n" + name_table_section)
