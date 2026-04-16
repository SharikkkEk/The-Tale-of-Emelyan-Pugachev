rows = 54
cols = 18
internal_id = 21300000

print("sprites:")
for row in range(rows):
    for col in range(cols):
        x = col * 32
        y = (rows - 1 - row) * 32
        idx = row * cols + col
        name = f"Block_{idx}"
        print(f"""    - serializedVersion: 2
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
      weights: []""")
        internal_id += 2

print("\nnameFileIdTable:")
internal_id = 21300000
for row in range(rows):
    for col in range(cols):
        idx = row * cols + col
        name = f"Block_{idx}"
        print(f"      {name}: {internal_id}")
        internal_id += 2
