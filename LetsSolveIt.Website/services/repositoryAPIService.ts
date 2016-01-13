module lsi {
	interface IModelCampaign extends ng.resource.IResource<lsi.ICampaign> {
	}

	interface IModelCategory extends ng.resource.IResource<lsi.ICategory> {
	}

	interface IModelSubmission extends ng.resource.IResource<lsi.ISubmission> {
	}

	interface IRepositoryAPIService {
		getAllCampaigns(): ng.resource.IResourceClass<IModelCampaign>;
        getCampaign(id: Number): ng.resource.IResourceClass<IModelCampaign>;
		getAllCategories(): ng.resource.IResourceClass<IModelCategory>;
		getCategory(id: Number): ng.resource.IResourceClass<IModelCategory>;
        getSubmissionsForCampaign(campaignId: Number): ng.resource.IResourceClass<IModelSubmission>;
        getAllSubmissions(): ng.resource.IResourceClass<IModelSubmission>;
        getSubmission(id: Number): ng.resource.IResourceClass<IModelSubmission>;
        //TODO - We need a IModelComment
        // getCommentForSubmission(submissionId: Number): ng.resource.IResourceClass<IModelComment>;
    }

	export class RepositoryAPIService implements IRepositoryAPIService {
		static $inject = ["$resource"]; // This trick protects the variable name from changing during any minification process of this source code.
		constructor(private $resource: ng.resource.IResourceService) {
		}

		getAllCampaigns(): ng.resource.IResourceClass<IModelCampaign> {
			var url: string = "api/Campaign";
			url = "http://localhost:33625/api/Campaign";

			return this.$resource(url);
		}

        getCampaign(id: Number): ng.resource.IResourceClass<IModelCampaign> {
            var url: string = "api/Campaign/" + id;
            url = "http://localhost:33625/api/Campaign/" + id.toString();

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

        getSubmissionsForCampaign(campaignId: Number): ng.resource.IResourceClass<IModelSubmission> {
            var url: string = "api/submission/campaign/" + campaignId.toString();

            return this.$resource(url);
        }

        // TODO - need to change the response object to be a list on integers.
		//getSubmissionIds(campaignId: Number): ng.resource.IResourceClass<IModelSubmission> {
  //          var url: string = "api/Campaign/" + campaignId.toString() + "/submission/id";

		//	return this.$resource(url);
		//}

        getAllSubmissions(): ng.resource.IResourceClass<IModelSubmission> {
            var url: string = "api/Submission";
            url = "http://localhost:33625/api/Submission";

            return this.$resource(url);
        }

        getSubmission(id: Number): ng.resource.IResourceClass<IModelSubmission> {
            var url: string = "api/Submission/" + id;
            url = "http://localhost:33625/api/Submission/" + id.toString();

            return this.$resource(url);
        }

        //// TODO Enable after a comment model has been added.
        //getCommentForSubmission(submissionId: Number): ng.resource.IResourceClass<IModelComment> {
        //    var url: string = "api/Comment/submission/" + submissionId.toString();

        //    return this.$resource(url);
        //}

    }

	angular.module("lsiServices") // Looks up an already defined module (by using 1 parameter).
		.service("repositoryAPIService", RepositoryAPIService)
	;
}