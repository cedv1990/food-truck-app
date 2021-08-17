const ApiBase = require('../base');

class ApiFoodTruck extends ApiBase {
    get apiUrlBase() {
        return '/foodtruck';
    }

    async getList() {
        try {
            const data = await this.get(this.apiUrlBase);
            console.log(data);
            return data;
        } catch (e) {
            return this.reject(e);
        }
    }
}

module.exports = new ApiFoodTruck();
