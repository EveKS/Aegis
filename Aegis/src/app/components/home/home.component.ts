import { Component, OnInit, Inject, OnDestroy, trigger, state, transition, style, animate, keyframes } from '@angular/core';
import { NgModel, NgForm } from '@angular/forms';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Subscription } from "rxjs/Subscription";
import { UserService } from "../../shared/services/user.service";
import { GetEmails } from "../../shared/models/get.emails.class";

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css'],
    animations: [
        trigger('flyInOut', [
            state('in', style({ transform: 'translateX(0)' })),
            transition('void => *', [
                style({ transform: 'translateX(-100%)' }),
                animate(200)
            ]),
            transition('* => void', [
                animate(200, style({ transform: 'translateX(100%)' }))
            ])
        ])
    ]
})
export class HomeComponent implements OnInit {
    emailGeted: boolean;
    category: string;
    categorys: string[];
    subscription: Subscription;

    constructor(private _http: Http, @Inject('BASE_URL') private _baseUrl: string) {
        this.emailGeted = false;
        this.category = '';
        this.categorys = [];
    }

    ngOnInit(): void {
        this.subscription = UserService.authNavStatus$.subscribe(status => {
            if (status) {
                this.getCategoris();
            }
        });
    }

    onClick(category: string): void {
        this.getSubCategory(category);
    }

    private getHeaders(): Headers {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json;charset=utf-8');
        let authToken = localStorage.getItem('auth_token');
        headers.append('Authorization', `Bearer ${authToken}`);

        return headers;
    }

    private getCategoris(): void {
        let headers = this.getHeaders();

        this._http.post(this._baseUrl + 'api/home/get-categorys', null, { headers: headers })
            .subscribe(result => {
                this.categorys = result.json() as string[];
            }, error => {
                console.log('ERROR');
                console.error(error);
            });
    }

    private getMails(category: string): void {
        let headers = this.getHeaders();

        let getEmails: GetEmails = Object.assign(new GetEmails(), {
            category: this.category,
            subCategory: category
        });

        const body = JSON.stringify(getEmails);

        this._http.post(this._baseUrl + 'api/home/get-emails', body, { headers: headers })
            .subscribe(result => {
                this.emailGeted = true;

                this.categorys = result.json() as string[];
            }, error => {
                console.log('ERROR');
                console.error(error);
            });
    }

    private getSubCategory(category: string): void {
        let headers = this.getHeaders();

        const body = JSON.stringify(category);

        this._http.post(this._baseUrl + 'api/home/get-subcategorys', body, { headers: headers })
            .subscribe(result => {
                this.category = category;

                this.categorys = result.json() as string[];
            }, error => {
                console.log('ERROR');
                console.error(error);
            });
    }
}
