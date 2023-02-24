//bubble.c 
//famous bubble sort
//implement the swap algorithm with pointers
//randomly generates values array

#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#define MAX 9

//input to work with
int values[] = {0, 0, 0, 0, 0, 0, 0, 0, 0};

//function prototypes
int isIn(int);
void generateValues();
void printValues();
void sort();
void swap(int*, int*);

//main function
int main(){
  generateValues();
  printf("Before: \n");
  printValues();
  sort();
  printf("After: \n");
  printValues();
  
  return(0);
} //end main

//function
int isIn(int number){
  //returns 1 if number is in values; 0 if number is not 
  int index;
  
  for(index = 0; index < MAX; index++){

    if(values[index] == number){
      return(1);
      index = 9;
    }else{
      if(index == 8){
	return(0);
      } //end if
    } //end if
	  
  } //end for
} //end isIn

void generateValues(){
  //generates a random integer. if the random integer is not in the values array, 
  //swap the random integer with a placeholder
  int index = 0;
  int i;

  time_t t;
  srand((unsigned) time(&t));  

  for(i = 0; i < 20; i++){
    int randomInt = (rand() % 100) +  1;

    if(isIn(randomInt) == 0){
      swap(&values[index], &randomInt);
      index++;
    } //end if
  } //end for
} //end generateValues

void printValues(){
  //print the values array
  printf("[");
  int index; 
	
  for(index = 0; index < MAX; index++){
    printf(" %d", values[index]);
  } //end for
  
  printf(" ]\n");
} //end printValues

void swap(int* high, int* low){
  int holdValue = *high; 
  *high = *low;
  *low = holdValue;
} //end swap

void sort(){
  //loop through all the elements in values array
  //if an element is greater than the next element, call swap() and printValues()
  int i, j;

  for(i = 0; i < (MAX); i++){
    for(j = 0; j < (MAX - 1); j++){
      if(values[j] > values[j + 1]){
        swap(&values[j], &values[j + 1]);
	printValues();
      } //end if 
    } //end for
  } //end for
} //end sort  
