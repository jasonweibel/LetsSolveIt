declare module lsi {
    export interface ICampaign {
        Id: number;
        UserName: string;
        Name: string;
        Description: string;
        Category?: any;
        CreatedDate: Date;
        LastModifiedDate: Date;
        StartDate: Date;
        EndDate: Date;
        MaxNumberOfUserVotes: number;
        State: boolean;
        InvitedUsers?: any;
    }
}