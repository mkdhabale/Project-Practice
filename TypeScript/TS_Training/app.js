"use strict";
exports.__esModule = true;
function add(n1, n2, showResult) {
    /*if(typeof n1 !=='number' || typeof n2 !=='number'){
        throw new Error('INcorrect input')
    }*/
    var res = n1 + n2;
    if (showResult)
        console.log(res);
}
var num1 = 41;
var num2 = 5.10;
var showResult = false;
add(num1, num2, showResult);
