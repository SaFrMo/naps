from bpy import context
import os
from PIL import Image

# set the layer to be layer 1
layers = [False]*32
layers[0] = True

# open and convert images in worker file
path = "C:/Unity/naps/workers/images"
for filename in os.listdir(path):
    img = Image.open(path + "/" + filename)
    print (img.format)