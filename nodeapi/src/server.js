'use strict';

const express = require('express');

const PORT = 3000;
const HOST = '0.0.0.0';

const app = express();

app.get('/oncall', (req, res) => {

    const onCallDeveloper = {
        name: 'Max',
        emailAddress: 'Max@aol.com'
        };
    res.header('Content-Type', 'application/json');
    const jsonResponse = JSON.stringify(onCallDeveloper);
res.send(jsonResponse);
});

app.listen(PORT, HOST);
console.log(`Your server is running at http://${HOST}:${PORT}`);