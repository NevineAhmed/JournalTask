import { Component, OnInit } from '@angular/core';
import {articleservService } from '../../_service/articleService.service';


import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import ArticleClass from '../../_Model/Article';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {

allArticles:ArticleClass[]=[]
oneArticle:ArticleClass
newArticle:ArticleClass=new ArticleClass(0,"","","","",false);
readArticle:ArticleClass
artId:number=0
config:any;

  constructor(private fb:FormBuilder,public ser:articleservService) {
    this.config = {
      itemsPerPage: 1,
      currentPage: 1
    }

   }
 
 userForm:FormGroup;
 messageValidator={
  Title:{
    required:"this field must be filled out",
    minLength:"you should enter at least one char",
    maxlength:"you should enter less than 50 char"
  },
  Description:{
    required:"this field must be filled out",
    minLength:"you should enter at least 15 char"
  }
}
  
  

 

  Add(){
   this.addArticle();
 }

 

 con(r){
   console.log(r);
 }

 ImageUrl:string="";
fileInfo:File=null;




  ngOnInit(): void {
   
    this.getall();
    
   this.oneArticle=new ArticleClass(0,"","","","",false);
    this.userForm=this.fb.group({
      title:["",[Validators.required,Validators.minLength(10),Validators.maxLength(150)]],
      description:["",[Validators.required,Validators.minLength(10),Validators.maxLength(150)]]
    
      });


      
  }
  
  
 

getall(){
   this.ser.getAll().subscribe(a=>{this.allArticles=a;console.log(a,this.allArticles)})
 
}
addArticle(){
 
   this.ser.postArticle(this.newArticle).subscribe(a=>{ console.log(a); this.getall();});
}
showupdate(id:number){
  this.ser.getOne(id).subscribe(a=>{this.oneArticle=a;console.log(a)})
console.log(id)
console.log(this.oneArticle);
}

read(item:ArticleClass){
  this.readArticle=item
}
updateArticle(){
  this.ser.updateArticle(this.oneArticle).subscribe(a=>{ this.oneArticle=a; this.getall();});
}
deleteArticle(item:ArticleClass){
 console.log(item)
  this.ser.deleteArticle(item.id).subscribe(a=> this.getall());

}


Transfer(item:ArticleClass){
    this.artId=item.id
}

approve(id:number){
  console.log(id)
this.ser.approveArticle(id).subscribe(a=>{console.log(a);this.getall()});
}
download(){
  this.ser.DownloadExel().subscribe(a=>a,err=>alert("there is an error")); 
}

handleFileInput(file:FileList){
  this.fileInfo=file.item(0);
  console.log(file);
  console.log(this.fileInfo);
  var reader= new FileReader();
  reader.onload=(event:any)=>{
    console.log(event);
    this.ImageUrl= event.target.result;
    console.log(this.ImageUrl);
  }
  reader.readAsDataURL(this.fileInfo);
  }

    pageChanged(event){
      this.config.currentPage = event;
     }

}
