import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import BookClass from '../_Model/Article';
import ArticleClass from '../_Model/Article';

@Injectable({
  providedIn: 'root'
})
export class articleservService {

  constructor(public http:HttpClient) { }
  urlcon:string="http://localhost:50565/";
  header={
    headers:new HttpHeaders({
  "Content-Type":"application/json"
    })
  }
  header2={
    headers:new HttpHeaders({
  "Content-Type":"application/json",
  "Authorization": "bearer "+localStorage.getItem("token")
    })
  }
  
  DownloadExel(){
    return this.http.get(this.urlcon+"Article/Exel",this.header);  
  }


getAll(){
  return this.http.get<ArticleClass[]>(this.urlcon+"Article/All",this.header);
}
  postArticle(article:ArticleClass){
    return this.http.post<ArticleClass>(this.urlcon+"Article/AddArticle",article,this.header);
} 
 updateArticle(article:ArticleClass){
    return this.http.put<ArticleClass>(this.urlcon+"Article/updateArticle",article,this.header);
} 
deleteArticle(id:number){
    return this.http.delete<ArticleClass>(this.urlcon+"Article/deleteArticle/"+id,this.header);
}

getOne(id:number){
  return this.http.get<ArticleClass>(this.urlcon+"Article/getOneArt/"+id,this.header);
}
approveArticle(id:number){
  return this.http.post<ArticleClass>(this.urlcon+"Article/updatePublished/"+id,this.header)
}


}
