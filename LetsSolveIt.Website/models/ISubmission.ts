declare module lsi {
    export interface ISubmission {
        Id: number;
        Campaign?: any;
        User?: any;
        Category?: any;
        Suggestion: string;
        Votes: number;
        CreatedDate: Date;
        LastModifiedDate: Date;
        State: boolean;
        InvitedUsers?: any;
    }
}

