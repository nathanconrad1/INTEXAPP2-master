// function setCookie(cname, cvalue, exdays) {
//     const d = new Date();
//     d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
//     let expires = "expires=" + d.toUTCString();
//     document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
// }

// function getCookie(cname) {
//     let name = cname + "=";
//     let decodedCookie = decodeURIComponent(document.cookie);
//     let ca = decodedCookie.split(';');
//     for (let i = 0; i < ca.length; i++) {
//         let c = ca[i];
//         while (c.charAt(0) == ' ') {
//             c = c.substring(1);
//         }
//         if (c.indexOf(name) == 0) {
//             return c.substring(name.length, c.length);
//         }
//     }
//     return "";
// }

// let x = getCookie("filters")

// for (cookie of x) {
//     allCookies = cookie.split(",");
//     for (val of allCookies) {
//         document.getElementById("output").innerHTML += "<div>" + val + "</div>"
//     }
// }

//Check for the filters cookie

if(document.cookie.indexOf("filters") >= 0) {
    let x = getCookie("filters")
    allCookies = x.split(",");
    for (val of allCookies) {
        document.getElementById("output").innerHTML += "<div>" + val + "</div>"
    }
}
