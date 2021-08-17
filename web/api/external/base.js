const fetch = require("node-fetch");

const config = require('../config');

const _apiUrlBase = config.REST_API_URL_BASE;

class ApiBase {
    async get(url, headers = {}) {
        return fetch(`${_apiUrlBase}${url}`, {
            headers,
        }).then(response => response.json());
    }

    reject(error) {
        return Promise.reject((error.response && error.response.data) || error);
    }
}

module.exports = ApiBase;
