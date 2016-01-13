var lsi;
(function (lsi) {
    var ActiveCampaingsController = (function () {
        function ActiveCampaingsController(repositoryAPIService) {
            this.repositoryAPIService = repositoryAPIService;
            this._repositoryAPIService = repositoryAPIService;
        }
        ActiveCampaingsController.prototype.GetAllCampaigns = function () {
            var _this = this;
            var resource = this._repositoryAPIService.getAllCampaigns();
            this.Message = "Fetching...";
            resource.query(
            //resource.get(
            function (value, httpResponce) {
                _this.Campaings = value.result;
                var n = _this.Campaings == null ? 0 : _this.Campaings.length;
                _this.Message = "Success: returned " + n.toString() + " elements";
            }, function (error) {
                console.debug(error);
                _this.Message = "Error Code " + error.status;
            });
        };
        ActiveCampaingsController.$inject = ["repositoryAPIService"]; // This will help for the minification process.
        return ActiveCampaingsController;
    })();
    angular
        .module("lsi") // Looks up an already defined module (by using 1 parameter).
        .controller("ActiveCampaingsController", ActiveCampaingsController);
})(lsi || (lsi = {}));
//# sourceMappingURL=activeCampaignsControler.js.map