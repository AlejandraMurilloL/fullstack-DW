export class CustomerDetail {
    id!: number;
    firstName!: string;
    lastName!: string;
    phone!: string;
    identificationDocument?: string;
    adress?: string;
    email?: string;
    dateOfBirth!: Date;
}