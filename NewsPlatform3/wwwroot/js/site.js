// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById("p_container").onload = function () { myAnim() };

function myAnim() {
    let id = null;
    const elem1 = document.getElementById("p1");
    const elem2 = document.getElementById("p2");
    const elem3 = document.getElementById("p3");
    let p = 1;
    let pos1 = 300;
    let pos2 = 600;
    let pos3 = 900;
    clearInterval(id);
    id = setInterval(frame, 10);
    function frame() {
        if (p == 1) {
            if (pos1 > 0) {
                pos1--;
                elem1.style.left = pos1 + "px";
            }
            else { p = 2; }
        }
        if (p == 2) {
            if (pos2 > 300) {
                pos2--;
                elem2.style.left = pos2 + "px";
            }
            else { p = 3; }
        }
        if (p == 3) {
            if (pos3 > 600) {
                pos3--;
                elem3.style.left = pos3 + "px";
            }
            else { p = -3; }
        }
        if (p == -3) {
            if (pos3 < 900) {
                pos3++;
                elem3.style.left = pos3 + "px";
            }
            else { p = -2; }
        }
        if (p == -2) {
            if (pos2 < 600) {
                pos2++;
                elem2.style.left = pos2 + "px";
            }
            else { p = -1; }
        }
        if (p == -1) {
            if (pos1 < 300) {
                pos1++;
                elem1.style.left = pos1 + "px";
            }
            else { p = 1; }
        }
    }
}
