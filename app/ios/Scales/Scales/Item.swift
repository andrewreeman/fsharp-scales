//
//  Item.swift
//  Scales
//
//  Created by Andrew Reeman on 26/05/2025.
//

import Foundation
import SwiftData

@Model
final class Item {
    var timestamp: Date
    
    init(timestamp: Date) {
        self.timestamp = timestamp
    }
}
