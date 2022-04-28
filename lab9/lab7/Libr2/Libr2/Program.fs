module Program
let retlist  list=
    let nlist=[for i in 1 .. List.max list->i]
    List.insertManyAt 0 nlist [] 
let reslist list =
    let nlist = List.sortDescending (List.distinct list)
    List.filter (fun x -> (List.contains x nlist)=false) (retlist list)
