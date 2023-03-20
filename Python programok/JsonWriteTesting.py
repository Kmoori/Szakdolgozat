import json
import time
import random

def WaitFewSec():
        time.sleep(5)
        WriteJsonFile()

def WriteJsonFile():
        coordinates_dictionary = {
                "x" : random.random(),
                "y" : random.random(),
                "z" : random.random()
        }
        json_object = json.dumps(coordinates_dictionary, indent=4)
        with open("C:/Users/Kmoor/AppData/LocalLow/DefaultCompany/Szakdolgozat/SaveData.json","w") as outf:
                outf.write(json_object)
        WaitFewSec()

WaitFewSec()
