import { Component } from '@angular/core';
import { NavBarComponent } from '../nav-bar-component/nav-bar-component';
import { RouterOutlet } from '@angular/router';
 
@Component({
  selector: 'app-home-page-component',
  imports: [NavBarComponent, RouterOutlet],
  templateUrl: './home-page-component.html',
  styleUrl: './home-page-component.css',
})
export class HomePageComponent {}
