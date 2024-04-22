function initializeValidations(conferenciaEste, conferenciaOeste) {
    $('#playoffForm').validate({
        rules: {
            'user-email': {
                required: true,
                email: true,
                maxlength: 50
            },
            'final-nba': {
                required: true
            },
            'este-2round-bracket0': {
                required: true
            },
            'este-2round-bracket1': {
                required: true
            },
            'este-2round-bracket2': {
                required: true
            },
            'este-2round-bracket3': {
                required: true
            },
            'este-3round-bracket0': {
                required: true
            },
            'este-3round-bracket1': {
                required: true
            },
            'oeste-2round-bracket0': {
                required: true
            },
            'oeste-2round-bracket1': {
                required: true
            },
            'oeste-2round-bracket2': {
                required: true
            },
            'oeste-2round-bracket3': {
                required: true
            },
            'oeste-3round-bracket0': {
                required: true
            },
            'oeste-3round-bracket1': {
                required: true
            }
        },
        messages: {
            'user-email': {
                required: "Email is required",
                email: "Please, enter an invalid email",
                maxlength: "Email max length is 50"
            },
            'final-nba': {
                required: ""
            },
            'oeste-3round-bracket0': {
                required: ""
            },
            'oeste-3round-bracket1': {
                required: ""
            },
            'oeste-2round-bracket0': {
                required: ""
            },
            'oeste-2round-bracket1': {
                required: ""
            },
            'oeste-2round-bracket2': {
                required: ""
            },
            'oeste-2round-bracket3': {
                required: ""
            },
            'este-3round-bracket0': {
                required: ""
            },
            'este-3round-bracket1': {
                required: ""
            },
            'este-2round-bracket0': {
                required: ""
            },
            'este-2round-bracket1': {
                required: ""
            },
            'este-2round-bracket2': {
                required: ""
            },
            'este-2round-bracket3': {
                required: ""
            }
        },
        errorClass: 'is-invalid',

        submitHandler: function (form) {
            return false;
        }
    });
}