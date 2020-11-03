#Sean Carlyle
#scarlyle@ucsc.edu
#Programming Assignment 5
#user inputs a positive integer and is shown all prime numbers less than or equal to that number

#functions--------------------------------------

#makeSieve()
def makeSieve(n):
    S = list(True for i in range(n+1))
    S[0] = False
    S[1] = False
    #iterate through list from 3rd list value to last list value, assigning all multiples of every prime as false.
    for i in range(2, len(S)):
        if S[i] == True:
            for k in range(i+1, len(S)):
                if k % i == 0:
                    S[k] = False
    return S
#end makeSieve()

#getPrimes()
def getPrimes(n):
    P = []
    S = makeSieve(n)
    for i in range(1, len(S)):
        if S[i] == True:
            P.append(i)
    return P
#end getPrimes()

#main program--------------------------------------
if __name__=='__main__':
    print()
    #asks user to input again if integer is not positive
    n = int(input("Enter a positive integer: "))
    while n < 1:
        n = int(input("Enter a positive integer: "))
    P = getPrimes(n)
    print()
    #prints every value in the list P, whenver iterator i+1 mod 10 is 0 create a new line
    print("There are "+str(len(P))+" prime numbers less than or equal to "+str(n)+":\n")
    for i in range(len(P)):
        print(P[i], end=" ")
        if (i+1) % 10 == 0:
            print()
    if(len(P) > 0):
        print("\n")
    else:
        print()
#end program------------------------------------------
