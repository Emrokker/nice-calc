fun main() {
    println("Hello World!\n")

    print("Please enter your name: ")
    val name = readlnOrNull()?.trim()

    print("Please enter your age: ")
    val age = readlnOrNull()?.trim()?.toIntOrNull() ?: 0

    val stringNameAge = (if (name.isNullOrEmpty()) "Anonymous" else name) + (if (age > 0) " ($age)" else "")

    println("\nWelcome to NiceCalc, $stringNameAge!\n")

    val math = MyMath()

    var exit = false
    while (!exit) {
        val calcMode = chooseCalcMode()

        var x: Int? = null
        var y: Int? = null

        while (null == x) {
            print("Enter first value: ")
            x = readlnOrNull()?.trim()?.toIntOrNull()
        }
        while (null == y || (4 == calcMode && 0 == y)) {
            print("Enter second value: ")
            y = readlnOrNull()?.trim()?.toIntOrNull()
        }

        var result: Int? = null
        when (calcMode) {
            1 -> result = math.add(x, y)
            2 -> result = math.subtract(x, y)
            3 -> result = math.multiply(x, y)
            4 -> result = math.divide(x, y)
            else -> {}
        }

        if (null == result) {
            println("Couldn't calculate a result!")
        } else {
            println("The result is: $result")
        }

        println()

        val confirm = arrayOf("yes", "y", "1")
        println("Do you wanna quit?")
        print("(${confirm.joinToString("/")}): ")
        if (confirm.contains(readlnOrNull()?.trim()?.lowercase())) exit = true

        println()
    }

    println("Thanks for using NiceCalc, until next time!\n")
}

fun chooseCalcMode(): Int {
    println("Choose an calculation mode:")

    val calcModes = arrayOf(1, 2, 3, 4)

    var calcMode: Int? = null
    while (null == calcMode || !calcModes.contains(calcMode)) {
        println("(${calcModes[0]}) Addition")
        println("(${calcModes[1]}) Subtraction")
        println("(${calcModes[2]}) Multiplication")
        println("(${calcModes[3]}) Division")

        calcMode = readlnOrNull()?.trim()?.toIntOrNull()
    }

    println()
    return calcMode
}
