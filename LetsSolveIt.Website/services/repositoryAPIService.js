var lsi;
(function (lsi) {
    var RepositoryAPIService = (function () {
        function RepositoryAPIService($resource) {
            this.$resource = $resource;
        }
        RepositoryAPIService.prototype.getAllCampaigns = function () {
            var url = "api/Campaign";
            url = "http://localhost:33625/api/Campaign";
            return this.$resource(url);
        };
        RepositoryAPIService.prototype.getCampaign = function (id) {
            var url = "api/Campaign/" + id;
            url = "http://localhost:33625/api/Campaign/" + id.toString();
            return this.$resource(url);
        };
        RepositoryAPIService.prototype.getAllCategories = function () {
            var url = "api/Category";
            return this.$resource(url);
        };
        RepositoryAPIService.prototype.getCategory = function (id) {
            var url = "api/Category/" + id.toString();
            return this.$resource(url);
        };
        RepositoryAPIService.prototype.getSubmissionsForCampaign = function (campaignId) {
            var url = "api/submission/campaign/" + campaignId.toString();
            return this.$resource(url);
        };
        // TODO - need to change the response object to be a list on integers.
        //getSubmissionIds(campaignId: Number): ng.resource.IResourceClass<IModelSubmission> {
        //          var url: string = "api/Campaign/" + campaignId.toString() + "/submission/id";
        //	return this.$resource(url);
        //}
        RepositoryAPIService.prototype.getAllSubmissions = function () {
            var url = "api/Submission";
            url = "http://localhost:33625/api/Submission";
            return this.$resource(url);
        };
        RepositoryAPIService.prototype.getSubmission = function (id) {
            var url = "api/Submission/" + id;
            url = "http://localhost:33625/api/Submission/" + id.toString();
            return this.$resource(url);
        };
        RepositoryAPIService.$inject = ["$resource"]; // This trick protects the variable name from changing during any minification process of this source code.
        return RepositoryAPIService;
    })();
    lsi.RepositoryAPIService = RepositoryAPIService;
    angular.module("lsiServices") // Looks up an already defined module (by using 1 parameter).
        .service("repositoryAPIService", RepositoryAPIService);
})(lsi || (lsi = {}));
//# sourceMappingURL=repositoryAPIService.js.map