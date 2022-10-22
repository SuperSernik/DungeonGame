from PIL import Image

def readMap(name, NEWmapWidth, NEWmapHeight):
    
    mapWidth = NEWmapWidth
    mapHeight = NEWmapHeight
    pixels = scanMap(name, "r")
    
    for j in range(mapWidth, len(pixels) + 1, mapWidth):
        print(pixels[j-mapWidth:j])
    

def saveMap(name, NEWmapWidth, NEWmapHeight):
    
    f = open(name + ".txt", "w")  
    mapWidth = NEWmapWidth
    mapHeight = NEWmapHeight
    pixels = scanMap(name, "s")
        
    for j in range(mapWidth, len(pixels) + 1, mapWidth):
        f.write(pixels[j-mapWidth:j])
        f.write("\n")
    f.close()


def scanMap(name, RS):
    
    im = Image.open(name + ".png")
    im.getdata()
    arr = list(im.getdata())

                                    # DEFAULT           ?
                                    # EMPYT SPACE       #
                                    
    BLACK = (0, 0, 0, 255)          # WALL              R
    WHITE = (255, 255, 255, 255)    # FLOOR             B
    BLUE = (0, 92, 255, 255)        # WATER             W
    GREEN = (106, 190, 48, 255)     # GRASS             G
    PINK = (255, 9, 216, 255)       # GLOWING SQUARE    A
    YELLOW = (251, 255, 54, 255)    # SANDISH           S
    LIGHTBLUE = (112, 247, 255, 255)# BLACK WHITE TILE  T
    GREY = (75, 75, 75, 255)        # COBBLE            E
    RED = (255, 0, 0, 255)          # LAVA              L
 

    if RS == "s":   
        WALL = "R"
        FLOOR = "B"
        WATER = "W"
        GRASS = "G"
        GLOWING_SQUARE = "A"
        SANDISH = "S"
        BW_TILE = "T"
        COBBLE = "E"
        LAVA = "L"
        
        
    if RS == "r":   
        WALL = "#"
        FLOOR = " "
        WATER = "~"
        GRASS = "="
        GLOWING_SQUARE = "+"
        SANDISH = ":"
        BW_TILE = "£"
        COBBLE = "_"
        LAVA = "$"

        
    DEFAULT = "?"
    pixels = ""
    for i in range(0, len(arr)):
        if arr[i] == BLACK:
           pixels += WALL
        elif arr[i] == WHITE:
           pixels += FLOOR
        elif arr[i] == BLUE:
           pixels += WATER
        elif arr[i] == GREEN:
           pixels += GRASS
        elif arr[i] == PINK:
           pixels += GLOWING_SQUARE
        elif arr[i] == YELLOW:
           pixels += SANDISH
        elif arr[i] == LIGHTBLUE:
            pixels += BW_TILE
        elif arr[i] == GREY:
            pixels += COBBLE
        elif arr[i] == RED:
            pixels += LAVA

           
        else:
            pixels += DEFAULT
           
    return pixels
    
#readMap("TestMap10x5", 10 ,5)

mapNameToMake = "LargeMapOne"
Mwidth = 100
Mheight = 100

readMap(mapNameToMake, Mwidth ,Mheight)
saveMap(mapNameToMake, Mwidth ,Mheight)
