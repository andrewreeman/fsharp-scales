//
//  ContentView.swift
//  Scales
//
//  Created by Andrew Reeman on 26/05/2025.
//

import SwiftUI
import SwiftData

struct ContentView: View {
    @Environment(\.modelContext) private var modelContext
    @Query private var items: [Item]
    @State private var scale = "Loading scale...";
    
    var body: some View {
        Text(scale)
            .onAppear {
                fetchData()
            }
    }
    
    private func addItem() {
        withAnimation {
            let newItem = Item(timestamp: Date())
            modelContext.insert(newItem)
        }
    }

    private func deleteItems(offsets: IndexSet) {
        withAnimation {
            for index in offsets {
                modelContext.delete(items[index])
            }
        }
    }
    
    private func fetchData() {
        // TODO: wait for permission when checking local network
        // TODO: ip in config somehow
        guard let url = URL(string: "http://192.168.0.219:5000/scale") else { return }

        URLSession.shared.dataTask(with: url) { data, response, error in
            guard let data = data else { return }
            do {
//                let posts = try JSONDecoder().decode([Post].self, from: data)
                let scaleString = String.init(data: data, encoding: .utf8)
                print(scaleString)
                DispatchQueue.main.async {
                    scale = scaleString ?? "Error loading scale"
//                    self.data = posts
                }
            } catch {
                print(error.localizedDescription)
            }
        }.resume()
    }
}

#Preview {
    ContentView()
        .modelContainer(for: Item.self, inMemory: true)
}


struct Post: Codable {
    let id: Int
    let title: String
    let body: String
}
