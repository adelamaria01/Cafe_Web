function Send() {
    var name = document.getElementById("nume").value;
    var email = document.getElementById("email").value;
    var message = document.getElementById("message").value;

    if (name && email && message) {
        var templateParams = {
            nume: name,
            email: email,
            message: message,
        };

        emailjs.send("service_wrg6prf", "template_9yq4b9f", templateParams)
            .then(function (response) {
                alert("Email sent successfully!");

            }, function (error) {
                alert("Email failed to send.");
            });
    } else {
        alert("Please fill in all input fields.");
    }

    return false;
}
