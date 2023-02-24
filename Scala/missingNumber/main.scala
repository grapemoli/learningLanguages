object Main {
  def main(args: Array[String]): Unit = {
    // get user input for arrA
    print("arrA size: ")
    var n = scala.io.StdIn.readInt()
    var arrA:Array[Int] = new Array[Int](n)
    
    for(i<-0 to (n-1)) {
      print("arrA #" + i + ": ")
      arrA(i) = scala.io.StdIn.readInt()
    } // end for

    // get user input for arrB
    print("\narrB size: ")
    var m = scala.io.StdIn.readInt()
    var arrB:Array[Int] = new Array[Int](m)

    for(i<-0 to (m-1)) {
      print("arrB #" + i + ": ")
      arrB(i) = scala.io.StdIn.readInt()
    } // end for    
    
    // put sorted arrays into maps
    var mapA:Map[Int, Array[Int]] = arrA.sorted.groupBy(i=>i) 
    var mapB:Map[Int, Array[Int]] = arrB.sorted.groupBy(i=>i)
    
    // print the unique values in mapB
    print("\nOutput: [")
    getUniqueBNum(mapA, mapB)
    print("]")
  } // end main

  /*
    getUniqueBNum()  
    Goal: give the numbers in mapB that are not in mapA
    Input: two maps mapA and mapB
    Output: prints all numbers that are in mapB but not in mapA
  */
  def getUniqueBNum(mapA: Map[Int, Array[Int]], mapB: Map[Int, Array[Int]]) = {
    // loop through every key in mapB, and try to find the key in mapA
    mapB.keys.foreach(key => { 
      // try to find mapB's key in mapA 
      val inA:Boolean = mapA.get(key).isDefined
      val frequencyInB:Int = mapB.get(key).get.length
  
      if(inA == false){
        print(key + ", ")
      }else if(frequencyInB > mapA.get(key).get.length){
        // mapB's key exists in A, but now we check for frequency
        // if the frequency in map B is greater than the frequency in mapA:
        // print the key
        print(key + ", ")
      } // end if-else
    }) // end for-each
  } // end getUniqueBNum
  
} // end class def
