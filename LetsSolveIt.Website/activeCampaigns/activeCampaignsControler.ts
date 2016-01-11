module lsi {
	interface IActiveCampaignsController {
		Campaings: ICampaign[];
		Message: String;

		GetAllCampaigns();
	}

	class ActiveCampaingsController implements IActiveCampaignsController {
		Campaings: ICampaign[];
		Message: String;

		_repositoryAPIService: lsi.RepositoryAPIService;

		static $inject = ["repositoryAPIService"]; // This will help for the minification process.
		constructor(private repositoryAPIService: lsi.RepositoryAPIService) {
			this._repositoryAPIService = repositoryAPIService;
		}

		GetAllCampaigns() {
			var resource = this._repositoryAPIService.getAllCampaigns();

			this.Message = "Fetching...";

			resource.get(
				(value, httpResponce) => {
					this.Campaings = value.result;
					this.Message = "Success";
				},

				(error) => {
					console.debug(error);
					this.Message = "Error Code " + error.status;
				}
			);
		}
	}

	angular
		.module("lsi") // Looks up an already defined module (by using 1 parameter).
		.controller("ActiveCampaingsController", ActiveCampaingsController);
}
