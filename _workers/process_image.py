#from bpy import context
import os
from PIL import Image

# set the layer to be layer 1
layers = [False]*32
layers[0] = True

# open and convert images in worker file
path = "C:/Unity/naps/Assets/_workers/images/"

for filename in os.listdir(path):
    # load the image
    img = Image.open(path + filename)
    # get the grid size
    resolution = 10
    width, height = (img.size[0], img.size[1])
    small = (width / 10, height / 10)
    normal = (width, height)
    # pixelize by shrinking and then growing
    img = img.resize(newSize, Image.NEAREST)
    img = img.resize (normal, Image.NEAREST)
    img.save(path + ".test", "JPEG")