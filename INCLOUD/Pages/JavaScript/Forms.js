function VerificationUserChange() {
    if (!Username())
        document.getElementById('userDiv').innerHTML = "User must be above 3 characters & start with a letter";
    else
        document.getElementById('userDiv').innerHTML = "";
    if (!FirstName())
        document.getElementById('finameDiv').innerHTML = "First name must be above 2 characters & start with CAPS";
    else
        document.getElementById('finameDiv').innerHTML = "";
    if (!LastName())
        document.getElementById('lanameDiv').innerHTML = "Last name must be above 2 characters & start with CAPS";
    else
        document.getElementById('lanameDiv').innerHTML = "";
    if (!PassMake())
        document.getElementById('passmakeDiv').innerHTML = "Password must be 6-20 characters";
    else
        document.getElementById('passmakeDiv').innerHTML = "";
    if (!PassMake2())
        document.getElementById('passmake2Div').innerHTML = "Password must match other password";
    else
        document.getElementById('passmake2Div').innerHTML = "";
    if (!GenderCheck())
        document.getElementById('genderDiv').innerHTML = "Must choose a gender";
    else
        document.getElementById('genderDiv').innerHTML = "";
    if (!CountrySelect())
        document.getElementById('countryDiv').innerHTML = "Must Choose a country";
    else
        document.getElementById('countryDiv').innerHTML = "";
    if (!BirthDate())
        document.getElementById('bdateDiv').innerHTML = "Must choose a birth date and it has to be after 1900";
    else
        document.getElementById('bdateDiv').innerHTML = "";
    if (!CheckCaptcha())
        document.getElementById('captchaDiv').innerHTML = "Must pass the captcha test";
    else
        document.getElementById('captchaDiv').innerHTML = "";
    return Username() && FirstName() && LastName() && GenderCheck() && CountrySelect() && BirthDate() && CheckCaptcha();
}
function mailVeri() {
    if (!Email()) {
        document.getElementById('emailErrDiv').innerHTML = "Not a valid Email";
    }
    else {
        document.getElementById('emailErrDiv').innerHTML = "";
    }
    return Email();
}
function sendMailMessage(verified) {
    if (verified) {
        document.getElementById('sentMailDiv').innerHTML = "Mail Sent! It can take up to a few minutes to be recived.";
        document.getElementById('emailErrDiv').innerHTML = "";
    }
    else {
        document.getElementById('sentMailDiv').innerHTML = "";
        document.getElementById('emailErrDiv').innerHTML = "Mail isn't registered!";
    }
}
function securityQuestVeri(verified) {
    if (!verified) {
        document.getElementById('secureDiv').innerHTML = "Wrong Answer!";
    }
    else {
        document.getElementById('secureDiv').innerHTML = "";
    }
}
function changePassVeri() {
    if (!CheckCaptcha())
        document.getElementById('captchaDiv').innerHTML = "Must pass captcha test";
    else
        document.getElementById('captchaDiv').innerHTML = "";
    if (!PassMake())
        document.getElementById('passmakeDiv').innerHTML = "Password must be 6-20 characters";
    else
        document.getElementById('passmakeDiv').innerHTML = "";
    if (!PassMake2())
        document.getElementById('passmake2Div').innerHTML = "Password must match other password";
    else
        document.getElementById('passmake2Div').innerHTML = "";
    return CheckCaptcha() && PassMake() && PassMake2();
}
function SignInVerification() {
    if (!CheckCaptcha())
        document.getElementById('captchaDiv').innerHTML = "Must pass captcha test";
    else
        document.getElementById('captchaDiv').innerHTML = "";
    return CheckCaptcha();
}
function loginVerification(verified) {
    if (!verified) {
        document.getElementById('loginNotValid').innerHTML = "Email and password doesn't match!";
    }
    else {
        document.getElementById('loginNotValid').innerHTML = "";
    }
}
function aspxVerification(emailExists) {
    if (emailExists) {
        document.getElementById('emailDiv').innerHTML = "Email already in use";
    }
    else {
        document.getElementById('emailDiv').innerHTML = "";
    }
}
function VerificationForms() {
    if (!Email())
        document.getElementById('emailDiv').innerHTML = "Enter a vaild E-mail";
    else
        document.getElementById('emailDiv').innerHTML = "";
    if (!Username())
        document.getElementById('userDiv').innerHTML = "User must be above 3 characters & start with a letter";
    else
        document.getElementById('userDiv').innerHTML = "";
    if (!FirstName())
        document.getElementById('finameDiv').innerHTML = "First name must be above 2 characters & start with CAPS";
    else
        document.getElementById('finameDiv').innerHTML = "";
    if (!LastName())
        document.getElementById('lanameDiv').innerHTML = "Last name must be above 2 characters & start with CAPS";
    else
        document.getElementById('lanameDiv').innerHTML = "";
    if (!PassMake())
        document.getElementById('passmakeDiv').innerHTML = "Password must be 6-20 characters";
    else
        document.getElementById('passmakeDiv').innerHTML = "";
    if (!PassMake2())
        document.getElementById('passmake2Div').innerHTML = "Password must match other password";
    else
        document.getElementById('passmake2Div').innerHTML = "";
    if (!SecurityQuestion())
        document.getElementById('queDiv').innerHTML = "Must select the security question";
    else
        document.getElementById('queDiv').innerHTML = "";
    if (!SecurityAnswer())
        document.getElementById('ansDiv').innerHTML = "Must fill the security answer";
    else
        document.getElementById('ansDiv').innerHTML = "";
    if (!GenderCheck())
        document.getElementById('genderDiv').innerHTML = "Must choose a gender";
    else
        document.getElementById('genderDiv').innerHTML = "";
    if (!CountrySelect())
        document.getElementById('countryDiv').innerHTML = "Must Choose a country";
    else
        document.getElementById('countryDiv').innerHTML = "";
    if (!BirthDate())
        document.getElementById('bdateDiv').innerHTML = "Must choose a birth date and it has to be after 1900";
    else
        document.getElementById('bdateDiv').innerHTML = "";
    if (!CheckCaptcha())
        document.getElementById('captchaDiv').innerHTML = "Must pass the captcha test";
    else
        document.getElementById('captchaDiv').innerHTML = "";
    return Email() && Username() && FirstName() && LastName() && PassMake() && PassMake2() && SecurityQuestion() && SecurityAnswer() && GenderCheck() && CountrySelect() && BirthDate() && CheckCaptcha();
}
function Email() { //Input is the Email - it checks if there is 1 '@' by checking if the last index of it is the same is the index of it. then it checks if the '@' isn't the first character and then if it's before the last index of '.'
    var emadress = document.getElementById('email').value;
    return emadress.lastIndexOf('@') == emadress.indexOf('@') && emadress.indexOf('@') > 0 && emadress.lastIndexOf('@') + 1 < emadress.lastIndexOf('.');
}
function Username() {
    var username = document.getElementById('reguser').value; //Input is the Username - it checks if the first character isn't a number and if it's longer then 3 characters
    return isNaN(username.charAt[0]) && username.length > 3;
}
function FirstName() {
    var finame = document.getElementById('finame').value; //Input is the First name- it checks if the first character is a capital letter and if it's longer than 2 characters
    return finame.charCodeAt(0) >= 65 && finame.charCodeAt(0) <= 90 && finame.length > 2;
}
function LastName() {
    var laname = document.getElementById('laname').value; //Input is the Last name- it checks if the first character is a capital letter and if it's longer than 2 characters
    return laname.charCodeAt(0) >= 65 && laname.charCodeAt(0) <= 90 && laname.length > 2;
}

function PassMake() { //Input is the Password - it checks if the length is above 5, shorter than 20 and contain something that isn't a letter
    var password = document.getElementById('passmake').value;
    if (password.length > 5 && password.length <= 20) {
        for (var i = 0; i < password.length; i++) {
            if (!password.charCodeAt(i) < 65 || (password.charCodeAt(i) > 90 && password.charCodeAt(i) < 97) || password.charCodeAt(i) > 122) {
                return true;
            }
        }
        return false;
    }
    return false;
}

function PassMake2() { //Input is the Password and the passsword check - it checks if they are the same
    var password = document.getElementById('passmake').value;
    var password2 = document.getElementById('passmake2').value;
    return password2 == password && password2 != "";
}
function SecurityQuestion() { //Input is the selected security question 1 - it checks if it's not NULL which is "Choose security question #1"
    var securequest = document.getElementById("securequest").value;
    return securequest != "NULL";
}
function SecurityAnswer() { //Input is the security answer - it checks if it is more then 0 characters
    var answer = document.getElementById('secureans').value;
    return answer.length > 0;
}
function GenderCheck() { //Input is the method of the radio buttons, it checks if 1 of them was chosen
    var gender = document.getElementsByName('gender');
    for (var i = 0; i < gender.length; i++)
        if (gender[i].checked)
            return true;
    return false;
}
function CountrySelect() { //Input is the selected country id - it checks if it's not null (The option "Choose  your country")
    var country = document.getElementById('country').value;
    return country != "NULL";
}
function BirthDate() { //Input is the birth date - it checks if the year is above 1900 and below 2019
    var bdateyear = document.getElementById('bdate').value.substring(0, 4);
    var bdate = document.getElementById('bdate').value;
    return bdateyear > 1900 && bdate != "" && bdateyear < 2019;
}
function CheckCaptcha() {
    var captcha = grecaptcha.getResponse();
    return captcha.length > 0
}