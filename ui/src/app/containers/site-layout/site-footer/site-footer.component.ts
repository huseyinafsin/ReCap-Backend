import { Component } from '@angular/core';
import { FooterComponent } from '@coreui/angular';
import { MailService } from '../../../services/mail.service';
import { MailSubscribe } from 'src/app/models/mailSubscribe';

@Component({
  selector: 'app-site-footer',
  templateUrl: './site-footer.component.html',
  styleUrls: ['./site-footer.component.scss'],
})
export class SiteFooterComponent extends FooterComponent {
  isSubscribed:boolean=false
  constructor(private mailService:MailService) {
    super()
   }

  ngOnInit(): void {

  }


  onSubscribe(email:string){
    let mailSubscribe:MailSubscribe = {id:0, email:email}
    this.mailService.add(mailSubscribe).subscribe(response =>{
      this.isSubscribed = response.success;
    })
  }
}

