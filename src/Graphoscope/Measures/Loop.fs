﻿namespace Graphoscope.Measures

open Graphoscope
open FSharpAux

type Loop() =

    /// <summary> 
    /// Get the amount of self loops. 
    /// </summary>
    /// <param name="graph">The graph to be analysed</param> 
    /// <returns>An int of the mean degree</returns>
    static member loopCountFGraph (graph : FGraph<'NodeKey,'NodeData,'EdgeData>) = 
        [|
            for values in graph do
                values.Key,
                values.Value|>fun (p,n,s) -> p
        |]
        |> Array.sumBy(fun (nk,v) -> 
            v.Keys|>Seq.countIf (fun x -> x=nk)
        )
    
    //TODO
    /// <summary> 
    /// Get the amount of self loops. 
    /// </summary>
    /// <param name="graph">The graph to be analysed</param> 
    /// <returns>An int of the mean degree</returns>
    static member loopCountOfDiGraph (graph: DiGraph<'NodeKey,'EdgeData>) = 
        failwith "not implemented yet"

    /// <summary> 
    /// Get the amount of self loops. 
    /// </summary>
    /// <param name="graph">The graph to be analysed</param> 
    /// <returns>An int of the mean degree</returns>
    static member loopCount (graph : FGraph<'NodeKey,'NodeData,'EdgeData>) = 
        Loop.loopCountFGraph graph
    
    /// <summary> 
    /// Get the amount of self loops. 
    /// </summary>
    /// <param name="graph">The graph to be analysed</param> 
    /// <returns>An int of the mean degree</returns>
    static member loopCount (graph: DiGraph<'NodeKey,'EdgeData>) = 
        Loop.loopCountOfDiGraph graph