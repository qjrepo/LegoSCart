import { Component, OnInit } from '@angular/core';

import { setTheme } from 'ngx-bootstrap/utils';
@Component({
  selector: 'app-legoshop',
  templateUrl: './legoshop.component.html',
  styleUrls: ['./legoshop.component.sass'],
  
  
})
export class LegoshopComponent implements OnInit {

  constructor() { 
    setTheme('bs4');
  }

  ngOnInit() {
  }

}
