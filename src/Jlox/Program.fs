open System
open System.IO

module Parser =

    type TokenType =
        // single character tokens
        | LEFT_PAREN
        | RIGHT_PAREN
        | LEFT_BRACE
        | RIGHT_BRACE
        | COMMA
        | DOT
        | MINUS
        | PLUS
        | SEMICOLON
        | SLASH
        | STAR
        // one or two character token
        | BANG
        | BANG_EQUAL
        | EQUAL
        | EQUAL_EQUAL
        | GREATER
        | GREATER_EQUAL
        | LESS
        | LESS_EQUAL
        // literals
        | IDENTIFIER of string
        | STRING of string
        | NUMBER of int
        // keywords
        | AND
        | CLASS
        | ELSE
        | FALSE
        | FUN
        | FOR
        | IF
        | NIL
        | OR
        | PRINT
        | RETURN
        | SUPER
        | THIS
        | TRUE
        | VAR
        | WHILE
        | EOF

    type Token = {
        Type: TokenType
        Lexeme: string
        Line: int
    }
    with override this.ToString () = sprintf "%A %s" this.Type this.Lexeme



module CLI =
    let runSourceCode sourceCode = ()

    let rec runPrompt () =
        printf ">"
        let line = System.Console.ReadLine()
        match line with
            | null -> ()
            | line ->
                runSourceCode line
                runPrompt ()

    let runFile sourceFile =
        let source = File.ReadAllText sourceFile
        runSourceCode source

    [<EntryPoint>]
    let main argv =
        match (argv |> List.ofArray) with
            | [] ->
                runPrompt ()
                0
            | [sourceFile] ->
                runFile sourceFile
                0
            | _ ->
                printf "Usage: jlox [script]"
                64
