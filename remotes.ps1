("karenlouise","vcihlar","laboyce","Ngiri","msamyford","mbuelow","playalien","mstrong","vinbin","jpaden","olliemuh","asteffes","andrewyon","neontapir","psteber","pescado") | foreach-object{

  git remote add $_ git://github.com/$_/nbdn_prep.git
}
