module lsi {
	interface IModelCampaign extends ng.resource.IResource<lsi.ICampaign> {
	}

	interface IModelCategory extends ng.resource.IResource<lsi.ICategory> {
	}

	interface IModelSubmission extends ng.resource.IResource<lsi.ISubmission> {
	}

	interface IRepositoryAPIService {
		getAllCampaigns(): ng.resource.IResourceClass<IModelCampaign>
		getAllCategories(): ng.resource.IResourceClass<IModelCategory>
		getCategory(id: Number): ng.resource.IResourceClass<IModelCategory>
		getSubmission(campaignId: Number): ng.resource.IResourceClass<IModelSubmission>
	}

	export class RepositoryAPIService implements IRepositoryAPIService {
		static $inject = ["$resource"]; // This trick protects the variable name from changing during any minification process of this source code.
		constructor(private $resource: ng.resource.IResourceService) {
		}

		getAllCampaigns(): ng.resource.IResourceClass<IModelCampaign> {
			var url: string = "api/Campaign";

			return this.$resource(url);
		}

		getAllCategories(): ng.resource.IResourceClass<IModelCategory> {
			var url: string = "api/Category";

			return this.$resource(url);
		}

		getCategory(id: Number): ng.resource.IResourceClass<IModelCategory> {
			var url: string = "api/Category/" + id.toString();

			return this.$resource(url);
		}

		getSubmission(campaignId: Number): ng.resource.IResourceClass<IModelSubmission> {
			var url: string = "api/Campaign/" + campaignId.toString() + "/";

			return this.$resource(url);
		}
	}

	angular.module("lsiServices") // Looks up an already defined module (by using 1 parameter).
		.service("repositoryAPIService", RepositoryAPIService)
	;
}