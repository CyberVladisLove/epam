function Calculator(math_exercise){
    const operators = /[\+,\-,\*,\/,\=]/ig;  
    let operatorArr = math_exercise.match(operators);
    const operandsPattern = /\d+(\.\d+)?/ig;
    let operandArr = math_exercise.match(operandsPattern);
    
    if(operandArr.length <= 0 || operatorArr.length <= 0) {
        return "введите корректный пример";
    }

    if(operandArr.length != operatorArr.length) {
        return "введите корректный пример"; 
    }
    
    let a = Number(operandArr[0]);
    let b = Number.NaN;

    for(let i = 0; i < operatorArr.length; i++) {
        switch (operatorArr[i]) {
            case "+":
                b = Number(operandArr[i+1]);
                a += b;
                break;
            
            case "-":
                b = Number(operandArr[i+1]);
                a -= b;
                break;
                
            case "*":
                b = Number(operandArr[i+1]);
                a *= b;
                break;
            
            case "/":
                b = Number(operandArr[i+1]);
                a /= b;
                break;
                
            case "=":
                return a.toFixed(2);

            default:     
                return "введите корректный пример"; 
        } 
    }
    return "введите корректный пример"; 
}

let math_exercise = prompt("Введите пример:", "");
alert(Calculator(math_exercise));