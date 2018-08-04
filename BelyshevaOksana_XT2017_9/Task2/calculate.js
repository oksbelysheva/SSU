document.getElementById("calculateButton").addEventListener('click', 
function(e) {
    var input = document.getElementById("inputText").value;
    var result;
    while (true) {
        var number1Reg = input.match(/^(([\+|-]?(([1-9][0-9]*)|([0-9]))\.[0-9]{1,})|([\+|\-]?(([1-9][0-9]*)|([0-9]))))/);
        var number1 = +number1Reg[0];
        input = input.replace(number1, '').trim();
        var sign = input[0];
        if (sign === "=") {
            break;
        }
        input = input.substring(1);
        var number2Reg = input.match(/^(([\+|-]?(([1-9][0-9]*)|([0-9]))\.[0-9]{1,})|([\+|\-]?(([1-9][0-9]*)|([0-9]))))/);
        var number2 = +number2Reg[0];
        if (sign === "+") {
            result = number1 + number2;
        }
        else if (sign === "*") {
            result = number1 * number2;
        }
        else if (sign === "-") {
            result = number1 - number2;
        }
        else if (sign === "/") {
            result = number1 / number2;
        }
        input = input.replace(number2, result).trim();
    }
    document.getElementById("result").value = result.toFixed(2);
});