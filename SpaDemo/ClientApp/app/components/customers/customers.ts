import { HttpClient, json } from "aurelia-fetch-client";
import { inject } from "aurelia-framework";

@inject(HttpClient)
export class Customers {
    public newCustomerName: string;
    public selectedCountry: ICountry;

    public http: HttpClient;

    constructor(http: HttpClient) {
        this.http = http;
        this.http.configure(config => {
            config.rejectErrorResponses();
        });

        this.fetchCountries();
        this.fetchCustomers();
    }

    public countries: ICountry[];
    private static countriesApiUrl = "/api/Countries";

    fetchCountries() {
        this.http.fetch(Customers.countriesApiUrl)
            .then(result => result.json() as Promise<ICountry[]>)
            .then(countries => {
                this.countries = countries;
            })
            .catch(error => {
                alert("Error fetching countries!");
            });
    }

    public customers: ICustomer[];
    private static customersApiUrl = "/api/Customers";

    fetchCustomers() {
        this.http.fetch(Customers.customersApiUrl)
            .then(result => result.json() as Promise<ICustomer[]>)
            .then(customers => {
                this.customers = customers;
            })
            .catch(error => {
                alert("Error fetching customers!");
            });
    }

    public addCustomer() {
        this.http.fetch(Customers.customersApiUrl, {
                method: "post",
                body: json({
                    name: this.newCustomerName,
                    country: {
                        id: this.selectedCountry.id,
                        name: this.selectedCountry.name
                    }
                })
            })
            .then(response => {
                this.newCustomerName = undefined;
                this.selectedCountry = undefined;
                this.fetchCustomers();
            })
            .catch(error => {
                alert("Error adding customer!");
            });
    }

    public removeCustomer(customer: ICustomer) {
        this.http.fetch(Customers.customersApiUrl + "/" + customer.id, {
            method: "delete"
        })
        .then(response => {
            this.fetchCustomers();
        })
        .catch(error => {
            alert("Error removing customer!");
        });
    }
}