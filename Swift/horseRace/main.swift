/*

file: main.swift

by: grace nguyen

date: October 19, 2022

purpose: implement the horse race a horse race

*/

// function definitions

/*

willMove(): simulate random horse movement behavior

inputs: nothing

outputs: true if horse moves

*/

func willMove() -> Bool {

  let randInt:Int = Int.random(in: 0...99)

  var move:Bool = false

  if randInt%2 == 1 {

    move = true

  }else{

    move = false

  } // end if-else

  return move

} // end horseMoves

/*

printTrack(): simulate the race track, printing all horse positions

input: the array of horse positions, and length of racetrack

output: nothing returned; horse positions are printed

*/

func printTrack(_ arr:inout[Int], _ length:Int) {

  for i in 0...4 {

    // LEFT SIDE

    var leftTrack:String = ""

    let leftSpaces:Int = arr[i] + 1

    for _ in stride(from: 1, to: leftSpaces, by: 1){ 

      leftTrack = leftTrack + "."

    } // end for

    

    // RIGHT SIDE

    var rightTrack:String = ""

    let rightSpaces:Int = length - arr[i]

    for _ in stride(from: 1, to: rightSpaces, by: 1) {

      rightTrack = rightTrack + "."

    } // end for

    // print the horse

    print(leftTrack + "\(i)" + rightTrack)

  } // end for

} // end printTrack

/*

start(): keep moving horses forward until horse reach end

input: horse array, length of track

output: returns nothing, prints the winner

*/

func start(_ arr:inout[Int], _ length:Int) {

  var keepGoing:Bool = true;

  var winner:String = "";

  while keepGoing {

    // randomly move horses one position forward

    for i in 0...4{

      let move:Bool = willMove()

      if(move == true) {

        arr[i] += 1;

      } // end if

    } // end for

    

    // check for winner

    for i in 0...4{

      if arr[i] == (length-1){

        keepGoing = false;

        winner = winner + String(i) + "," // account for >1 winner

      } // end if

    } // end for

    // print horses

    print("\n")

    printTrack(&arr, length)

  } // end while

  

  print("Winner: \(winner)!")

  

} // end start

// main

func main() {

  var horses = [0, 0, 0, 0, 0] 

  

  // get user input

  print("Length of race track: ")

  

  if let userInput = readLine() {

    let length = Int(userInput) ?? 10

    // race time!

    start(&horses, length)

  } // end if-let

} // end main

// call method(s)

main()
