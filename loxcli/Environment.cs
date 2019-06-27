﻿using System;
using System.Collections.Generic;

namespace loxcli {
    class Environment {
        private readonly Dictionary<string, object> values = new Dictionary<string, object>();
        public readonly Environment enclosing;

        public Environment() {
            enclosing = null;
        }

        public Environment(Environment enclosing) {
            this.enclosing = enclosing;
        }

        public void Define(string name, object value) {
            values.Add(name, value);
        }

        public object Get(Token name) {
            if (values.ContainsKey(name.lexeme)) {
                return values[name.lexeme];
            }

            if (enclosing != null) {
                return enclosing.Get(name);
            }

            throw new RuntimeError(name, "Undefined variable '" + name.lexeme + "'.");
        }

        public void Assign(Token name, Object value) {
            if (values.ContainsKey(name.lexeme)) {
                values[name.lexeme] = value;
                return;
            }

            if (enclosing != null) {
                enclosing.Assign(name, value);
                return;
            }
            
                throw new RuntimeError(name, "Undefined variable '" + name.lexeme + "'");
            
        }


    }
}