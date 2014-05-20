#from bpy import context
import os
from PIL import Image

# from http://www.sintacks.com/2012/06/python-calculating-average-color-of.html
def get_average_color((x,y), nX, nY, image):
    """ Returns a 3-tuple containing the RGB value of the average color of the
    given square bounded area of length = n whose origin (top left corner)
    is (x, y) in the given image"""
 
    r, g, b = 0, 0, 0
    count = 0
    for s in range(x, x+nX+1):
        for t in range(y, y+nY+1):
            pixlr, pixlg, pixlb = image[s, t]
            r += pixlr
            g += pixlg
            b += pixlb
            count += 1
    return ((r/count), (g/count), (b/count))

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
    img = img.resize(small, Image.NEAREST)
    img = img.resize (normal, Image.NEAREST)
    # how many X and Y grid boxes are there?
    spacesX = width / resolution
    spacesY = height / resolution
    # create the template image for Blender
    template = Image.new("RGB", (spacesX, spacesY), "black")
    template_pixels = template.load()
    # get pixel list
    img_pixels = img.load()
    # iterate through all columns in all rows
    r, g, b = (0, 0, 0)
    current_x = 0
    current_y = 0
    for x in range(x):
        for y in range (height):
            template_pixels[current_x, current_y] = get_average_color((x, y), 1, img_pixels)
        current_x += 1
        current_y += 1
            



    # save new image
    template.save(path + ".test", "JPEG")