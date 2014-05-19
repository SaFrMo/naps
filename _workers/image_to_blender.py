from bpy import context
import os
import bpy

# where text guides are stored
path = "C:/Unity/naps/Assets/_workers/text/"

def convert_to_shadower(filename):
    # open the relevant file
    with open(path + filename) as f:
        while True:
            # read next character
            c = f.read(1)
            # stop reading at EOF
            if not c:
                break
            # create new line at EOL
            if c == '\n':
                coordinates[0] = 0
                coordinates[1] += 1
            # light (no block)
            if c == "1":
                print (c)
            # shadow (block created)
            else:
                bpy.ops.mesh.primitive_cube_add(radius=.5, location=coordinates, layers=layer)
            # go to the next space
            coordinates[0] += 1
            

coordinates = [0, 0, 0]

layer = [False] * 20
layer[0] = True

# every file in the home directory
for filename in os.listdir(path):
    convert_to_shadower(filename)