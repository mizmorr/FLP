open System

    let rec max d a =
        match d with
        |d when (d%10)>a&&(d%10)%3<>0 -> max (d/10) (d%10)
        |d when d=0->a
        |d->max(d/10) a

let obmax a =
    max a 0


