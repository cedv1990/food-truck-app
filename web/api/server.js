const express = require('express');
const bodyParser = require('body-parser');
const foodTruckController = require('./controllers/food-truck');

const app = express();

var router = express.Router();

const port = process.env.PORT || 3500;

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

app.use('/api/food-truck', foodTruckController);

app.listen(port, () => console.log(`Listening on port ${port}`));