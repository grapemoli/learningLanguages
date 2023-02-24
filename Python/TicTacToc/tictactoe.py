## tic tac toe
## 05.13.22
## grace nguyen



## functions
## name-related functions
def getName(playerNum):
    keepGoing = True
    
    while(keepGoing):
        name = input("Player " + playerNum + ": What is your name? ")
        name = name.strip()

        if(name == ""):
            print("You cannot have an empty name!")
        else:
            keepGoing = False
            return(name)



## board-related functions
def getBoard():
    # ask user for board size, and return array of inputted len
    keepGoing = True
    board = []
    
    while(keepGoing):
        try:
            userInput = input("Input a board size: ")
            size = int(userInput)
            
            # board must be at least 2x2
            if(size >= 2):
                # note: board is a square matrix
                # i.e. same width as length
                for i in range(size):
                    rowElements = []

                    for j in range(size):
                        rowElements.append(0)
                    
                    board.append(rowElements)
                keepGoing = False
            else:
                print("Board must be greater than 1x1!")
                keepGoing = True

        except:
            print("Please input an accepted value.")

    return(board)

def printBoard(array):
    # print the board with an easy user experience to read
    size = len(array)
    one = "O"
    two = "X"

    # print the column numbers
    columnNumbers = "        "
    for i in range(size):
        columnNumbers = columnNumbers + str(i + 1) + "  "
    
    columnNumbers += "\n"
    print(columnNumbers)

    # print the board & row numbers
    for i in range(size):
        string = str(i + 1) + "    ["
        
        for j in range(size):
            player = str(array[i][j])

            if(player == "0"):    
                string = string + "  -"
            elif(player == "1"):
                string = string + "  O"
            else:
                string = string + "  X"
               
        
        string = string + "  ]"
        print(string)    

def changeBoard(array, coordinates, playerNumber):
    # note: 1 = playerOne has played here; 2 = playerTwo has played here
    column = coordinates[0]
    row = coordinates[1]
    array[column][row] = playerNumber
    
    return(array)

def isEmpty(array, coordinates):
    # return true if data spot is empty
    column = coordinates[0]
    row = coordinates[1]
    isEmpty = False

    if(array[column][row] == 0):
        isEmpty = True
    
    return(isEmpty)



## winner-related functions
def endGame(array, player, coordinates):
    endGame = False

    emptySpaces = False

    for i in range(len(array)):
        for j in range(len(array)):
            if(array[i][j] == 0):
                emptySpaces = True

    # 1. game ends when there remains no more spaces to play
    if(emptySpaces == False):
        endGame = True
        print("Game Ends! Truce!")

    # 2. game ends when there are no more spaces to play  
    else:
        winner = getWinner(array, coordinates)

        if(winner != 0):
            endGame = True
            print("Game Ends! Player " + str(player[0]) + ", " + player[1] + ", wins!")        

    return(endGame)

def getWinner(array, coordinates):
    winner = 0
    size = len(array)
    row = coordinates[0]
    column = coordinates[1]

    rowSum = 0
    columnSum = 0
    mainDiagonalSum = 0
    offDiagonalSum = 0

    for i in range(size):
        # player one 'pieces' will subtract one from the sum, while
        # player two 'pieces' will add one to the sum
        # winner if size is +/- the size of the board

        # check coordinates' corresponding row and column 
        if(array[row][i] != 0):
            rowSum += pow(-1, array[row][i])
        
        if(array[i][column] != 0):
            columnSum += pow(-1, array[i][column])

        # check diagonal
        if(array[i][i] != 0):
            mainDiagonalSum += pow(-1, array[i][i])

        if(array[size - i - 1][i] != 0):
            offDiagonalSum += pow(-1, array[size - i - 1][i])

    # get winner
    if( (rowSum == size) or (columnSum == size) or (mainDiagonalSum == size) or (offDiagonalSum == size)):
        winner = 2
    elif((abs(rowSum) == size) or (abs(columnSum) == size) or (abs(mainDiagonalSum) == size) or (abs(offDiagonalSum) == size)):   
        winner = 1
    else:
        winner = 0
        
    return(winner)        



## user gameplay-related functions
def play(array, player):
    # ask user where they would like to play
    keepGoing = True
    
    while(keepGoing):
        print("\n")
        printBoard(array)

        print("\nPlayer " + str(player[0]) + ": " + player[1])

        try:
            userRow = int(input("Row: ").strip()) - 1 # account for user experience: shifted index +1
            userColumn = int(input("Column: ").strip()) - 1 # account for user experience: shifted index +1
            coordinates = (userRow, userColumn)

            if(isEmpty(array, coordinates) == True):
                changeBoard(array, coordinates, player[0])
                keepGoing = False
            else:
                print("This spot has already been played! Choose again.")
        except:
            print("Invalid input. Try again!")

    winner = endGame(array, player, coordinates)
    return(winner)

def playGame():
    playerOne = (1, getName("one"))
    playerTwo = (2, getName("two"))
    board = getBoard()
    
    keepGoing = True

    while(keepGoing):
        one = play(board, playerOne)
        

        if(one == True):
            keepGoing = False
        else:
            two = play(board, playerTwo)
            
            if(two == True):
                keepGoing = False
            else:
                keepGoing = True



## main function
def main():
    keepGoing = True
    
    while(keepGoing):
        play = input("\n\nPlay? ").strip().lower()

        if( (play == "yes") or (play == "y") ):
            playGame()
        elif( (play == "no") or (play == "n") ):
            keepGoing = False
        else:
            print("Invalid input. Try again.")
        


## call main function
if(__name__ == "__main__"):
    main()
