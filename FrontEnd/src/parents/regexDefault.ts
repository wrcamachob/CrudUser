export const regexType = {
    default: {
        exp: '^[a-zA-Z0-9ñÑáéíóúüÁÉÍÓÚÜ,.\\-_\\s]*$',
        message: 'Formato inválido, no use caracteres especiales'
    },
    word: {
        exp: '^[a-zA-Z0-9ñÑáéíóúüÁÉÍÓÚÜ,.\\-_]*$',
        message: 'Formato inválido, no use caracteres especiales ni espacios'
    },
    alphanumberWord: {
        exp: '^[a-zA-Z0-9]*$',
        message: 'Formato alfanúmerico inválido'
    },
    charWord: {
        exp: '^[a-zA-Z]*$',
        message: 'Formato de caracteres inválido'
    },
    anyWord: {
        exp: '^\\S*$',
        message: 'Formato inválido'
    },
    percent: {
        exp: '^100$|^[0-9]{1,2}$|^[0-9]{1,2}\\.[0-9]{1,2}$',
        message: 'Formato de porcentaje inválido, use el punto decimal (.)'
    },
    email: {
        exp: '[a-z0-9]+@[a-z]+\.[a-z]{2,3}',
        message: 'Formato de e-mail inválido'
    },
    number: {
        exp: '^[0-9]*$',
        message: 'Formato de número inválido'
    },
    numberslash: {
        exp: '^[0-9\/]*$',
        message: 'Formato de número inválido'
    },
    time24: {
        exp: '^([01]?[0-9]|2[0-3]):[0-5][0-9]$',
        message: 'Formato de hora militar inválido, use 23:45'
    },
    date: {
        exp: '^[0-9]{1,2}/[0-9]{1,2}/[0-9]{4}$',
        message: 'Formato de fecha inválido',
        internal: 'dd/mm/yyyy'
    }
};
